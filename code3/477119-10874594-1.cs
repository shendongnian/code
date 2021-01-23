            // The following will fail to regroup
            //(MyItems[3] as TestClass).Category = "D";
            // The following works
            MyItems.EditItem(MyItems[3]);
            (MyItems[3] as TestClass).Category = "D";
            MyItems.CommitEdit();
            // The following will also fail to regroup            
            //(MyItems[3] as TestClass).Category = "D";
            //items[3] = items[3];
            // fails as well, surprisingly
            //(MyItems[3] as TestClass).Category = "D";
            //TestClass tmp = items[3];
            //items.RemoveAt(3);
            //items.Insert(3, tmp);
