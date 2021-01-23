    public ActionResult Index()
    {
        // The model could be of any form and come from anywhere but
        // the important thing is that at the end of the day you will have
        // a list of titles here
        var model = new[] 
        { 
            "17\" Screen", 
            "100GB HD", 
            "10788 Firewire", 
            "Lock Cable", 
            "Monitor",
            "Mouse", 
            "Keyboard",
            "USB" 
        };
        // Now let's map this domain model into a view model 
        // that will be adapted to the requirements of our view.
        // And the requirements of this view is to group the titles
        // in ranges of 3 letters of the alphabet
        var viewModel = Enumerable
            .Range(65, 26)
            .Select((letter, index) => new 
            { 
                Letter = ((char)letter).ToString(), 
                Index = index 
            })
            .GroupBy(g => g.Index / 3)
            .Select(g => g.Select(x => x.Letter).ToArray())
            .Select(range => new MyViewModel
            {
                LetterRange = string.Format("{0}-{1}", range.First(), range.Last()),
                Titles = model
                    .Where(item => item.Length > 0 && range.Contains(item.Substring(0, 1)))
                    .ToArray()
            })
            .ToArray();
        // Let's add those titles that weren't starting with an alphabet letter
        var other = new MyViewModel
        {
            LetterRange = "Other",
            Titles = model.Where(item => !viewModel.Any(x => x.Titles.Contains(item))).ToArray()
        };
        // and merge them into the final view model
        viewModel = new[] { other }.Concat(viewModel).ToArray();
        return View(viewModel);
    }
