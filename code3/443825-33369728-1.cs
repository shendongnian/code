        // POST api/<controller>
        [HttpPost]
        [ActionName("ListArray")]
        public IEnumerable<Contact> Post([FromBody]IEnumerable<int> ids)
        {
            IEnumerable<Contact> result = null;
            if (ids != null && ids.Count() > 0)
            {
                return contactRepository.Fill(ids);
            }
            return result;
        }
