    void ShowCards(List<Work> workItems) {
        cardsPanel.SuspendLayout();
        CacheCards(cardsPanel.Controls);
        int y = 5;
        foreach(var work in workItems) {
            var card = GetCardFromCache(work);
            card.Top = y;
            card.Left = 10;
            y += card.Height + 5;
            cardsPanel.Controls.Add(card);
        }
        cardsPanel.ResumeLayout(true);
    }
    //
    Stack<WorkDisplayControl> cache;
    void CacheCards(Control.ControlCollection controls) {
        if(cache == null)
            cache = new Stack<WorkDisplayControl>();
        foreach(WorkDisplayControl wdc in controls)
            cache.Push(wdc);
        controls.Clear();
    }
    WorkDisplayControl GetCardFromCache(Work data) {
        WorkDisplayControl result = (cache.Count > 0) ?
            cache.Pop() : new WorkDisplayControl();
        result.InitData(data);
        return result;
    }
