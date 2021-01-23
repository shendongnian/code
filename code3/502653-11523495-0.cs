                var result=(
                            from product in context.Products
                            join child1 in context.Child1s
                            on product.ID equals child1.ProductID
                            join child2 in context.Child2s
                            on product.ID equals child2.ProductID
                            join child3 in context.Child3s
                            on product.ID equals child3.ProductID
                            join child4 in context.Child4s
                            on product.ID equals child4.ProductID
                            where product.ID<1000
                            select new {
                                            
                                            AnonTypeProduct=product,
                                            AnonTypeChild1=child1,
                                            AnonTypeChild2=child2,
                                            AnonTypeChild3=child3,
                                            AnonTypeChild4=child4,
                            
                            }).ToList();
            IEnumerable<Child1> ch1list=new IEnumerable<Child1>();
            IEnumerable<Child2> ch2list =new IEnumerable<Child2>();
            IEnumerable<Child3> ch3list=new IEnumerable<Child3>();
            IEnumerable<Child4> ch4list=new IEnumerable<Child4>();
            foreach(var result in results)
            {
                Child1 ch1=new Child1();
                ch1=result.AnonTypeChild1;
                ch1.Product=AnonTypeProduct;
                Child2 ch2=new Child2();
                ch2=result.AnonTypeChild2;
                ch2.Product=AnonTypeProduct;
                Child3 ch3=new Child3();
                ch3=result.AnonTypeChild3;
                ch3.Product=AnonTypeProduct;
                Child1 ch4=new Child4();
                ch4=result.AnonTypeChild4;
                ch4.Product=AnonTypeProduct;
                ch1list.Add(ch1);
                ch1list.Add(ch2);
                ch1list.Add(ch3);
                ch1list.Add(ch4);
            }
