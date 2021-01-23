    public class UserController : ApiController {
    
        public IEnumerable<UserDTO> GetAllUsers() {
            GWDataSet gw = new GWDataSet();
            usersTableAdapter adapter = new usersTableAdapter();
            adapter.Fill(gw.users);
    
            List<UserDTO> list = new List<UserDTO>();
    
            foreach(DataRow row in gw.users.Rows) 
            {
                UserDTO user = new UserDTO();
                user.FirstName = row["Name"].ToString();
                // fill properties
    
               list.Add(user);
            }
    
            return list;
        }
    }
