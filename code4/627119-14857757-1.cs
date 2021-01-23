    public class Client {
        public string Name { get; set; }
    }
    private void button2_Click(object sender, EventArgs e)
    {
            Stack<Client> st = new Stack<Client>();
            st.Push(new Client { "joginder" });
            st.Push(new Client { "singh" });
            st.Push(new Client { "banger" });
    }
