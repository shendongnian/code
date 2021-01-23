     public SelectSubject()
        {
            this.InitializeComponent(); // not required 
            objselectsubjectViewmodel = new SelectSubjectViewModel(); // not required 
            groupedItemsViewSource.Source = objselectsubjectViewmodel.Categories; // not required the way set the itemssource of grid.
            this.DataContext = this;
            checkClass obj = checkClass.GetInstance();
            if (obj.lstSubSelectedItems.Count > 0)
            {
             //   List<Subject> sjsfj = new List<Subject>();
                //    ICollection<Subject> fg = new ICollection<Subject>();
                itemGridView.SelectAll();
             //   int i = 0;
                List<int> lstIndex = new List<int>();
                foreach (Subject item1 in itemGridView.SelectedItems)
                {
                    foreach (var item3 in obj.lstSubSelectedItems)
                    {
                        if (item3.SubjectCategory == item1.SubjectCategory && item3.SubjectName == item1.SubjectName)
                        {
                            lstIndex.Add(itemGridView.SelectedItems.IndexOf(item1));
                        }
                    }
                }
                int l = itemGridView.SelectedItems.Count;
                for (int b = l-1; b >= 0; b--)
                {
                    if (!lstIndex.Contains(b))
                    {
                        itemGridView.SelectedItems.RemoveAt(b);
                    }
                }
            }
          
        }
