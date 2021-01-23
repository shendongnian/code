            List<LabEntity> selected = originalSettings.SelectedInstanceLabs;
            List<LabEntity> available = Presenter.GetLabs(dateRange);
            if (!firstLoad)
            {
                //Remove selected labs
                available = available.Except<LabEntity>(selected).ToList();
            }  
