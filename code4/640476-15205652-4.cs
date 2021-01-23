    MyRecursiveObject obj = new MyRecursiveObject {    
        Id = 1,
        Parent = new MyRecursiveObject {
            Id = 2,
            Parent = new MyRecursiveObject { Id = 3 }
        }
    };
    GetAllParentIdsOf(obj).ToList().ForEach(Console.WriteLine);
    // 2
    // 3
