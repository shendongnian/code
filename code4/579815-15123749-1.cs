        public List<OrderModelView> GetAllOrdersAscByName() {
            using (IUnitOfWork context = new EntityContainer()) {
                Repository<Order> orderRepository = new Repository<Order>(context);
                var orders = orderRepository.GetAll()
                    .Select(o => new OrderModelView {
                        OrderID = o.OrderID,
                        Name = o.Name,
                        OrderTypeCount = o.OrderTypes.Count
                    })
                    .OrderBy(o => o.Name)
                    .ToList();
                return orders;
            }
        }
