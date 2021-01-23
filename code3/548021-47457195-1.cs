    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Linq.Expressions;
      /// <summary> Gets property information.</summary>
      /// <exception cref="ArgumentException">
      ///   Thrown when one or more arguments have unsupported or illegal values.
      /// </exception>
      /// <typeparam name="TSource">   Type of the source. </typeparam>
      /// <typeparam name="TProperty"> Type of the property. </typeparam>
      /// <param name="source">         Source for the. </param>
      /// <param name="propertyLambda"> The property lambda. </param>
      /// <returns> The property information.</returns>
      public static PropertyInfo GetPropertyInfo<TSource, TProperty>(
          TSource source,
          Expression<Func<TSource, TProperty>> propertyLambda)
      {
         Type type = typeof(TSource);
    
         MemberExpression member = propertyLambda.Body as MemberExpression;
         if (member == null)
            throw new ArgumentException(string.Format(
                "Expression '{0}' refers to a method, not a property.",
                propertyLambda.ToString()));
     PropertyInfo propInfo = member.Member as PropertyInfo;
     if (propInfo == null)
        throw new ArgumentException(string.Format(
            "Expression '{0}' refers to a field, not a property.",
            propertyLambda.ToString()));
     if (propInfo.ReflectedType != null && (type != propInfo.ReflectedType &&
                                            !type.IsSubclassOf(propInfo.ReflectedType)))
        throw new ArgumentException(string.Format(
            "Expresion '{0}' refers to a property that is not from type {1}.",
            propertyLambda.ToString(),
            type));
     return propInfo;
      }
          /// <summary> An IQueryable&lt;T&gt; extension method that distinct by a certain property.</summary>
          /// <exception cref="NullReferenceException"> Thrown when the underlying Session value was unexpectedly null. </exception>
          /// <typeparam name="T">  The result type of the IQueryable. </typeparam>
          /// <typeparam name="T1"> The property type. </typeparam>
          /// <param name="query">      The query to act on. </param>
          /// <param name="expression"> The expression, that references the property. </param>
          /// <returns> An IQueryable&lt;T&gt;</returns>
          public static IQueryable<T> DistinctBy<T, T1>(this IQueryable<T> query, Expression<Func<T, T1>> expression)
          {
             var distinctSelection = query.Select(expression);
             var info = GetPropertyInfo(default(T), expression);
             var propertyInfo = query.Provider.GetType().GetProperty("Session", BindingFlags.NonPublic | BindingFlags.Instance);
             if (propertyInfo == null)
             {
                throw new NullReferenceException("The underliying Session is not defined!");
             }
             ISession session = propertyInfo.GetValue(query.Provider, null) as ISession;
             var result = session.Query<T>().Where("x => @0.Contains( x." + info.Name + ")", distinctSelection);
             return result;
          }
       }
          /// <summary> An IQueryable&lt;T&gt; extension method that distinct by two properties (composite key).</summary>
          /// <exception cref="ArgumentNullException">  Thrown when one or more required arguments are null. </exception>
          /// <exception cref="NullReferenceException"> Thrown when a value was unexpectedly null. </exception>
          /// <typeparam name="T">  The resulting type. </typeparam>
          /// <typeparam name="T1"> The type of the first property. </typeparam>
          /// <typeparam name="T2"> The type of the second property. </typeparam>
          /// <param name="query">          The query to act on. </param>
          /// <param name="expressionKey1"> The first expression key (property 1 or key 1). </param>
          /// <param name="expressionKey2"> The second expression key (property 2 or key 2). </param>
          /// <returns> An IQueryable&lt;T&gt;</returns>
          public static IQueryable<T> DistinctBy<T, T1, T2>(this IQueryable<T> query, Expression<Func<T, T1>> expressionKey1, Expression<Func<T, T2>> expressionKey2)
          {
             if (expressionKey1 == null)
             {
                throw new ArgumentNullException("expressionKey1");
             }
             if (expressionKey2 == null)
             {
                return query.DistinctBy(expressionKey1);
             }
             var propertyInfo = query.Provider.GetType().GetProperty("Session", BindingFlags.NonPublic | BindingFlags.Instance);
             if (propertyInfo == null)
             {
                throw new NullReferenceException("The underliying Session is not defined!");
             }
             ISession session = propertyInfo.GetValue(query.Provider, null) as ISession;
             var info1 = GetPropertyInfo(default(T), expressionKey1);
             var info2 = GetPropertyInfo(default(T), expressionKey2);
    
             var result = session.Query<T>().Where("k => @0.Any(k1 => k1." + info1.Name + " == k." + info1.Name + " && k1." + info2.Name + " == k." + info2.Name + ")", query);
    
             return result;
          }
