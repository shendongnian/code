    var merged = list1
         .MergeWith(list2, i => i.ProjectId,
           (lhs,rhs) => new Project{ProjectId=lhs.ProjectId,ProjectName=lhs.ProjectName, Customer=rhs.Customer})
        .MergeWith(list3,i => i.ProjectId,
           (lhs,rhs) => new Project{ProjectId=lhs.ProjectId,ProjectName=lhs.ProjectName, Customer=lhs.Customer,Address=rhs.Address});
            
