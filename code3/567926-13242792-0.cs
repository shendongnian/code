    public interface IScene<out T> where T : SceneModel { }
    public class Scene<T> : IScene<T> where T : SceneModel { }
    List<IScene<SceneModel>> list = new List<IScene<SceneModel>>();
    list.Add(new WorldScene());
    list.Add(new BattleScene());
    foreach (IScene<SceneModel> scene in list) ...
