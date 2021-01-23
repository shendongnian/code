    public List<object> ShowMessage2(DataTable dtInput)
        {
            List<object> objectList = new List<object>();
            foreach(DataRow dr in dtInput.Rows)
            {
                MyObj newObj = new MyObj();
                newObj.ID = Convert.ToInt32(dr["ID"]);  // Beware of the possible conversion errors due to type mismatches
                newObj.Name = dr["Name"].ToString();
                objectList.Add(newObj);
            }
            return objectList;
        }
    public class MyObj
    {
        public int ID { get; set; }
        public string Name { get; set; }        
    }
 
