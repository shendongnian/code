        public List<Client_Dto> GetClientByBehandelaar(string loggedInUserId)
        {
            try
            {
                int userID = Convert.ToInt32(loggedInUserId);
                List<Client_Dto> result = new List<Client_Dto>();
                using (nestorDBDataContext db = new nestorDBDataContext())
                {
                    IEnumerable<Client_Dto> client_dto =
                        (from relaties in db.tbl_Relaties
                         where relaties.ID_Persoon == userID
                         select relaties);
                    result = client_dto.ToList();
                    return result;
                }                               
            }
            catch (Exception e)
            {
                throw new ArgumentException("GetClientByBehandelaar Failed " + e);
            }
        }
