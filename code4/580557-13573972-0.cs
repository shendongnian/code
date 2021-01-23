    public void AddChildrenUnit(Unit unit) // 10 ms
    {
        AddChilrenUnit(unit, new SqlConnection(_connectionString));
    }
    
    public void AddChildrenUnit(Unit unit, SqlConnection connection)
    {
        using (var trans = new TransactionScope())
        using (connection))
        using (var cmd = new SqlCommand("INSERT INTO UNIT (Name,TemplateId,ParentId,CreatedAt,HierarchyIndex) VALUES (@Name,@TemplateId,@ParentId,@CreatedAt,@HierarchyIndex);Select Scope_Identity();",con))
        {
            con.Open();
    
            // INSERT new child at the end of the children which is the highest HierarchyIndex                
            cmd.Parameters.AddWithValue("HierarchyIndex", unit.HierarchyIndex); 
            cmd.Parameters.AddWithValue("TemplateId", unit.TemplateId);
            cmd.Parameters.AddWithValue("Name", unit.Name);
            cmd.Parameters.Add("CreatedAt", SqlDbType.DateTime2).Value = unit.CreatedAt; 
    
            unit.UnitId = Convert.ToInt32(cmd.ExecuteScalar());
    
            trans.Complete();
        }             
        
    }
