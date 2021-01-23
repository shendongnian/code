    public static Expression<Func<T,bool>> IsVisible<T>(DateTime now) 
        where T:IHaveItem
    {
       return x => x.Item.DateVisible != null &&
              x.Item.DateVisible < now;
    }
