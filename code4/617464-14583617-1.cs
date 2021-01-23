    var group = query.Where(isSel=>isSel.isSelected).GroupBy(x => new
    {
       ...
       TestName =  x.ClassA.Name 
    })
    .Union(query.Where(isSel=>!isSel.isSelected).GroupBy(x => new
    {
       ...
       TestName = "" 
    });
