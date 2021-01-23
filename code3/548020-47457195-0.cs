    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Linq.Expressions;
          /// <summary> An IQueryable&lt;T&gt; extension method that distinct by a certain property.</summary>
          /// <exception cref="NullReferenceException"> Thrown when the underlying Session value was unexpectedly null. </exception>
          /// <typeparam name="T">  The result type of the IQueryable. </typeparam>
          /// <typeparam name="T1"> The property type. </typeparam>
          /// <param name="query">      The query to act on. </param>
          /// <param name="expression"> The expression, that references the property. </param>
          /// <returns> An IQueryable&lt;T&gt;</returns>
          public static IQueryable<T> DistinctBy<T, T1>(this IQueryable<T> query, Expression<Func<T, T1>> expression)
          {
             //var distinctSelection = query.Select(expression).Distinct();
             var distinctSelection = query.Select(expression).Distinct();
             var info = SystemExtensions.GetPropertyInfo(default(T), expression);
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
