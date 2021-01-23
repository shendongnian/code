        public void Update(string id, Delta<MEMBERS> obj)
        {
            var memToUpdate = context.MEMBERS.Find(obj.MEMBERID);
            if (memToUpdate != null)
            {
                obj.Patch(memToUpdate);
                int result = context.SaveChanges();
                System.Diagnostics.Debug.WriteLine("save result:" + result);
            }
        }
