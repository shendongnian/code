    var ids = new List<ObjectId> 
                 { 
                    new ObjectId { ClassName = "Rectangle1", ID = 1 }, 
                    new ObjectId { ClassName = "Rectangle2", ID = 2 } 
                 };
    string code = txtFilter.Text; (Ex: "item => item.ClassName == \"Rectangle1\"" ;)
    Func<ObjectId, bool> func = ExpressionParser.Compile<Func<ObjectId, bool>>(code);      
    
    ids.ForEach(obejctId => 
            {
                Console.WriteLine(func.Invoke(obejctId));
            });
