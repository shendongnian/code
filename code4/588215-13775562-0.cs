    public static IEnumerable<Category> Flatten(this Category category)
    {
        if (category.Categories != null)
        {
            foreach (var sub in category.Categories)
            {
                foreach (var subSub in sub.Flatten())
                    yield return subSub;
            }
        }
        yield return category;
    }
