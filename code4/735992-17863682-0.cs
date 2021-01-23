    var bindingObjs = new List<DataBindingObj>();
    foreach(var obj in dataFromDatabase)
    {
        var bindingObj = new DataBindingObj { DateRemoved = obj.DateRemoved.ToShortDateString() };
        bindingObjs.Add(bindingObj);
    }
    dataGridView1.AutoGenerateColumns = true;
    dataGridView1.DataSource = bindingObjs;
