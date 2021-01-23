    SqlBulkCopy bulkcopy = new SqlBulkCopy(myConnection);
    //I assume you have created the table previously
    //Someone else here already showed how  
    bulkcopy.DestinationTableName = table.TableName;
    try                             
    {                                 
        bulkcopy.WriteToServer(table);                            
    }     
        catch(Exception e)
    {
        messagebox.show(e.message);
    } 
