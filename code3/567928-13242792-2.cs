    public interface IScene<out T> where T : SceneModel { }
        // use of T is limited to return values and out parameters
    public class Scene<T> : IScene<T> where T : SceneModel { }
    List<IScene<SceneModel>> list = new List<IScene<SceneModel>>();
    list.Add(new WorldScene());
    list.Add(new BattleScene());
    foreach (IScene<SceneModel> scene in list) ...
