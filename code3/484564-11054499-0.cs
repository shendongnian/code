    public static TSource SetCommonProperties<TSource>(this TSource input, EntityBaseClass entity)     where TSource : EntitySmallBase 
    { 
       input.Id = entity.Id; 
       input.Name = entity.Name; 
       input.ShortName = entity.Name; 
 
       this.Update(input); // Or this method could exist in any other class or static class.
 
      return input; 
