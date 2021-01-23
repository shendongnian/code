       public Item GetItem(string name, DbContext context) {
            using(var context) {
                return context.Items.FirstOrDefault(item => item.Id == id);
            }
        }
