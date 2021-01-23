    using (linqWishesDataContext dataContext = new linqWishesDataContext())
    {
        foreach (WishlistUpvote vote in destinationVotes)
        {
            try
            {
                dataContext.WishlistUpvotes.InsertOnSubmit(vote);
                dataContext.SubmitChanges();
            }
            catch { }
        }
    }
