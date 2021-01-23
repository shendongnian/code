        public void Save(Item i)
        {
            using (var context = new ItemContext())
            {
                foreach (var subitem in i.SubItems)
                {
                    if (subitem.SubItemId == 0)
                        context.Set<SubItem>().Add(subitem);
                    else
                        context.Set<SubItem>().Attach(subitem);
                }
                context.Set<Item>().Attach(i);
                context.SaveChanges();
            }
        }
