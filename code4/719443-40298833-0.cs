    query.DataSources = new QueryServiceReference.QueryDataSourceMetadata[1];
    
    // Set the properties on Customers data source.
     customerDataSource = new QueryServiceReference.QueryDataSourceMetadata();
     customerDataSource.Name = "Customers";
     customerDataSource.Enabled = true;
     customerDataSource.FetchMode = QueryServiceReference.FetchMode.OneToOne;
     customerDataSource.Table = "CustTable";
     //customerDataSource.DynamicFieldList = false;
    
    query.DataSources[0] = customerDataSource;
    
    
     QueryServiceReference.QueryDataSourceMetadata dirPartyTableDataSource = new QueryServiceReference.QueryDataSourceMetadata();
     dirPartyTableDataSource.Name = "DirPartyTable";
     dirPartyTableDataSource.Table = "DirPartyTable";
     dirPartyTableDataSource.Enabled = true;
     dirPartyTableDataSource.DynamicFieldList = true;
    
    
     customerDataSource.DataSources = new QueryServiceReference.QueryDataSourceMetadata[1] { dirPartyTableDataSource };
     QueryServiceReference.QueryRelationMetadata relation = new QueryServiceReference.QueryRelationMetadata();
    
     //this is also one way of setting the relation 
     //relation.JoinRelation = "DirPartyTable_FK"; //table relation defined in AOT
     //relation.JoinDataSource = customerDataSource.Name; //parent datasource name
    
    relation.Table = "CustTable";//Parent table
     relation.Field = "Party"; 
     relation.RelatedTable = "DirPartyTable"; // child table
     relation.RelatedField = "RecId";
     relation.JoinDataSource = customerDataSource.Name; 
     dirPartyTableDataSource.Relations = new QueryServiceReference.QueryRelationMetadata[1] { relation };
