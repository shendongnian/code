    public static class JobFactory
    {
        public Job GetJob(string id)
        {
            switch (id)
            {
                case "CA":
                    return new Carpenter();
                ...
            }
        }
    }
