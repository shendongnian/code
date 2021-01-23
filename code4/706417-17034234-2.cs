    ObjectType1 obj1 = new ObjectType1();
    
    foo(obj1);
    
    void foo(IObject fm)
            {
                ObjectType1 cls;
                if (fm is ObjectType1)
                {
                    cls = fm as ObjectType1;
                    cls.ID = 10;
                    MessageBox.Show(cls.ID.ToString() + "    " + cls.GetType().ToString());
                } 
            }
