    public interface IScriptable
    {
        Vector3 Position;
    }
    public abstract class CommandSettings<T>
    {
        public List<Command<T>> Parameters = new List<Command<T>>(4);
        public abstract Command<T> Load();
    }
    public class CommandRandomSettings : CommandSettings<float>
    {
        public Command<float> Load()
        {
            return null;
        }
    }
    public class CommandPositionSettings : CommandSettings<object>
    {
        public Command<object> Load()
        {
            return null;
        }
    }
    public abstract class Command<T>
    {
        public List<Command<T>> Parameters = new List<Command<T>>(4);
        public Command(CommandSettings<T> settings)
        {
            Parameters = settings.Parameters;
        }
        public abstract T Execute(IScriptable scriptableObject);
        public abstract int GetArgumentCount();
        public abstract CommandSettings<T> Write();
    }
    public class CommandRandom : Command<float>
    {
        public CommandRandom(CommandRandomSettings settings)
            : base(settings = settings == null ? new CommandRandomSettings() : settings)
        {
            if (settings == null)
            {
                settings = new CommandRandomSettings();
            }
        }
        public override float Execute()
        {
            return 0.0f;
        }
        public override int GetArgumentCount()
        {
            return 2;
        }
        public override CommandSettings<float> Write()
        {
            CommandRandomSettings settings = new CommandRandomSettings();
            settings.Parameters.AddRange(Parameters);
            return settings;
        }
    }
    public class CommandPosition : Command<object>
    {
        public CommandPosition(CommandPositionSettings settings)
            : base(settings = settings == null ? new CommandPositionSettings() : settings)
        {
            if (settings == null)
            {
                settings = new CommandPositionSettings();
            }
        }
        public override object Execute(IScriptable scriptableObject)
        {
            Vector3 position = new Vector3();
            position.X = Parameters[0].Execute();
            position.Y = Parameters[1].Execute();
            position.Z = Parameters[2].Execute();
            scriptableObject.Position = position;
        }
        public override int GetArgumentCount()
        {
            return 3;
        }
        public override CommandSettings<object> Write()
        {
            CommandPositionSettings settings = new CommandPositionSettings();
            settings.Parameters.AddRange(Parameters);
            return settings;
        }
    }
