    public class Estandar {
        public int Id { get; set; }
    }
    public interface IConector {
        IEnumerable<Estandar> listar(string name, Estandar estandar, object key);   
    }
    [TestMethod]
    public void CheckAnonymous() {
        var connector = new Mock<IConector>();
        connector.Setup(cn => cn.listar("FetchEstandar",
                                        It.IsAny<Estandar>(),
                                        It.Is<object>(it => MatchKey(it, 1))))
                 .Returns(new List<Estandar> { new Estandar { Id = 1 } });
        var entidad = connector.Object.listar("FetchEstandar", new Estandar(), new { Id = 1 });
        Assert.AreEqual(1, entidad.Count());
    }
    public static bool MatchKey(object key, int soughtId) {
        var ret = false;
        var prop = key.GetType().GetProperty("Id");
        if (prop != null) {
            var id = (int)prop.GetValue(key, null);
            ret = id == soughtId;
        }
        return  ret;
    }
