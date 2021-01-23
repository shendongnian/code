    public void DeleteMyFood(string foodId)
    {
        using (FoodDataContext context = new FoodDataContext(Con_String))
        {
            string listboxindex = listboxid;
            IQueryable<FoodViewModel> foodQuery = from c in context.FoodTable where c.C_ID.ToString() == foodId select c;
            // .. rest of code here ..
        }
    }
