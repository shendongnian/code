    List<Order> orders=new List<Order>
                {new Order(){State="cali",ID=1},
                new Order(){State="cali",ID=2},
                new Order(){State="nali",ID=3},
                new Order(){State="pali",ID=4},
                new Order(){State="pali",ID=5},
                new Order(){State="cali",ID=3},
            };
            List<Order> gr=null;
            orders.GroupBy(g => g.State).ToList().ForEach(d=>
            {
                if(gr==null)
                    gr = d.ToList<Order>();
                else if (gr.Count() < d.Count())
                    gr = d.ToList<Order>();
                         
            });
            return gr;
