        QueryTask queryTask = new QueryTask("http://sampleserver1.arcgisonline.com/ArcGIS/rest/services/Specialty/ESRI_StateCityHighway_USA/MapServer/1/");
        queryTask.ExecuteCompleted += QueryTask_ExecuteCompleted;
        queryTask.Failed += QueryTask_Failed;
    
        ESRI.ArcGIS.Client.Tasks.Query query = new ESRI.ArcGIS.Client.Tasks.Query();
        query.Text = "e";
        query.ReturnGeometry = false;
        
        queryTask.ExecuteAsync(query);
    
    
    private void QueryTask_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
    {
        FeatureSet featureSet = args.FeatureSet
        // use the featureSet to do something. It contains everything you need
    }
