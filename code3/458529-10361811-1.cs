    public delegate void UpdateForm(IEnumerable<string> data, int foo);
    ...
    public void UpdateFormMethod(IEnumerable<string> data, int foo) {
        foreach (var str in data.Where(str => 
                   !fcon_container_users_list.Items.Contains(str))) {
            fcon_container_users_list.Items.Insert(0, str);
        }
    }
