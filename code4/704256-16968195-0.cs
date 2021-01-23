    public partial class Form1 : Form
    {
        HttpSelfHostServer server;
        HttpSelfHostConfiguration config;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private async void button1_Click(object sender, EventArgs e)
        {
            config = new HttpSelfHostConfiguration("http://localhost:9090");
    
            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
    
            HttpSelfHostServer server = new HttpSelfHostServer(config);
            await server.OpenAsync();
            // Server is running: you can show something to user like - it is running
            MessageBox.Show("Server is ready!");
        }
    
        private async void button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9090");
  
            string query = string.Format("api/products?category={0}", "testes");
    
            var resp = await client.GetAsync(query);
    
            var products = await resp.Content.ReadAsAsync<string>();
            MessageBox.Show(products);
        }
    }
