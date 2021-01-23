    void reinit()
    {
      if (_adrlinks == null) return;
      listAdr.Items.Clear();
      foreach(var li in ListAdr.SelectedItems)
      {
        foreach (LnkAdresse ele in _adrlinks)
        {
          if (((Filter == eFilter.all) || (Filter == eFilter.basic && ele.RType <= 1) || (Filter == eFilter.synteilnehmer && ele.RType == 8)
                    || (Filter == eFilter.deliveryteam && ele.RType >= 16 && ele.RType <= 31) || (Filter == eFilter.explorationteam && ele.RType >= 32 && ele.RType <= 63))
                    && (int)ele.mut >= 0)
          {
            listAdr.Items.Add(ele);  //listAdr is my listview
            // commented out as it won't ever be true in a multiselect scenario
            // and wouldn't make any sense if it did 
            //if (ele == li) listAdr.SelectedItem = li;
          }
        }
      }
      //NotifyContent("changeDoc", "", "");
    }
