    public static Expression<Func<TTargetObject,Boolean>> IsGoodChildFunctional<TTargetObject>(Int32 childType, Int32 childSize)
    {
                var e = Expression.Parameter(typeof(TTargetObject), "e");
                var childTypeMember = Expression.MakeMemberAccess(e, typeof(TTargetObject).GetProperty("childType"));
                var childSizeMember = Expression.MakeMemberAccess(e, typeof(TTargetObject).GetProperty("childSize"));
                var  childTypeConstant = Expression.Constant(childType, childType.GetType());
                var  childSizeConstant = Expression.Constant(childSize, childSize.GetType());
                BinaryExpression b;
                BinaryExpression bBis;
                Expression<Func<TTargetObject, bool>> returnedExpression;
                b = Expression.Equal(childTypeMember , childTypeConstant );
                bBis2 = Expression.Equal(childSizeMember, c2);
                var resultExpression = Expression.AndAlso(b, bBis);
                returnedExpression = Expression.Lambda<Func<TTargetObject, bool>>(resultExpression , e);
                return returnedExpression;
    }
