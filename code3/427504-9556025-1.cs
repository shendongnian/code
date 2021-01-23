    public Form1()
    {
        InitializeComponent();
        //your playing with IQueryable<TableFoos>
        _repo = new ObservableHelper<TableFoos>()
    
        Observable.FromEventPattern(h => textBox1.KeyUp += h,
                               h => textBox1.KeyUp -= h)//tell Rx about our event
            .Throttle(TimeSpan.FromMilliseconds(500), cs)///throttle
            .ObserveOn(Scheduler.Dispatcher);//so we have no cross threading issues
            .Do(a => SearchList(textBox1.Text))//do this method 
            .Subscribe();
    }
    IObservableHelper<TableFoos, PdvEntities> _repo;
    void SearchList(string query)
    {//AS MANY keystrokes are there, this function will be called only
     // once every 500 milliseconds..
        listBox1.Items.Clear();
        listBox1.BeginUpdate();
        var getfn = _repo.GetAllAsObservables
            (d => d.TableFoos.Where(c => c.TableFoos.Contains(query)));
        getfn.ObserveOn(this).Subscribe(resultList => //is an IList<TableFoos>
            {
                foreach (var item in resultList)
                {
                    listBox1.Items.Add(...
                }
                listBox1.EndUpdate();
            });
    }
