    public class Foo
    {
        public dynamic Bar { get; set; }
    }
    var foo = new Foo { Bar = new { A = 1, B = "abc", C = true } };
    Debug.WriteLine(RavenJObject.FromObject(foo).ToString(Formatting.None));
    Debug.WriteLine(JsonConvert.SerializeObject(foo, Formatting.None));
