        public static List<Comment> ToTree(List<Comment> FlatCommentsList)
        {
            List<Comment> TopComments = FlatCommentsList.Where<Comment>(x => x.ParentItemID == 0).ToList();
            List<Comment> NestedComments = FlatCommentsList.Where<Comment>(x => x.ParentItemID > 0).ToList();
            List<int> IdsToRemove;
            while (NestedComments.Count > 0)
            {
                IdsToRemove = new List<int>();
                NestedComments.ForEach(x =>
                {
                    Comment ParentComment = TopComments.Where<Comment>(y => y.ItemID == x.ParentItemID).SingleOrDefault<Comment>();
                    if (ParentComment != null)
                    {
                        ParentComment.ChildComments.Add(x);
                        IdsToRemove.Add(x.ItemID);
                    }    
                });
                NestedComments.RemoveAll(x => IdsToRemove.Contains(x.ItemID));
            }
            return TopComments;
        }
