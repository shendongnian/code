    public class BaseScene<T>
        where T : SceneModel
    {
        public IList<T> Models {get; set;}
    }
    public class Scene : BaseScene<SceneModel>
    {
    }
    
    public class WorldScene : BaseScene<WorldModel>
    {    
    }
