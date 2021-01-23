     bool SortDateAsc = true;
        private void Date_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (SortDateAsc)
            {
                ObservableCollection<InvoicesDTO> a = new ObservableCollection<InvoicesDTO>(((ResolutionVM)this.DataContext).MainInvoiceList.OrderBy(oc => oc.FC_AGE));
                ((ResolutionVM)this.DataContext).MainInvoiceList = a;
                InvoiceGrid.ItemsSource = ((ResolutionVM)this.DataContext).MainInvoiceList.ToList();
                SortDateAsc = false;
                ((ResolutionVM)this.DataContext).RefreshSelctedInvoice();
            }
            else
            {
                ObservableCollection<InvoicesDTO> a = new ObservableCollection<InvoicesDTO>(((ResolutionVM)this.DataContext).MainInvoiceList.OrderByDescending(oc => oc.FC_AGE));
                ((ResolutionVM)this.DataContext).MainInvoiceList = a;
                InvoiceGrid.ItemsSource = ((ResolutionVM)this.DataContext).MainInvoiceList.ToList();
                SortDateAsc = true;
                ((ResolutionVM)this.DataContext).RefreshSelctedInvoice();
            }
        }
