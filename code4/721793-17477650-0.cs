    public void DeleteNews(Predicate<News> item)
    {
        //myList is list of News
        myList.RemoveAll(item);
    }
