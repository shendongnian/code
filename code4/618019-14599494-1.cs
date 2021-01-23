    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    class YourClass
    {
        public static List<TEntity> DoSomething<TEntity>(DbContext db, string valor, string atributo)
            where TEntity : class
        {
            var mParam = Expression.Parameter(typeof(TEntity));
            var matches = db.Set<TEntity>()
                            .Where(Expression.Lambda<Func<TEntity, bool>>(
                                Expression.Call(
                                    Expression.Convert(
                                        Expression.Property(mParam, atributo),
                                        typeof(String)
                                        ),
                                    "Contains",
                                    new Type[0],
                                    Expression.Constant(valor)
                                    ),
                                mParam
                             ));
            return matches.ToList();
        }
    }
