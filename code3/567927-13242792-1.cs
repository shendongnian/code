    public interface IScene { }
    public class Scene<T> : IScene where T : SceneModel { }
    List<IScene> list = new List<IScene>();
    list.Add(new WorldScene());
    list.Add(new BattleScene());
    foreach (IScene scene in list) ...
