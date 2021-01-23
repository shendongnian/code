    // This is the one we want to use our In extension method on:
    public enum FriendlyEnum
    {
        A,
        B,
        C
    }
    public enum EnemyEnum
    {
        A,
        B,
        C
    }
    // The extension method:
    public static class FriendlyEnumExtensions
    {
        public static bool In(this FriendlyEnum value, params FriendlyEnum[] list)
        {
            return list.Contains(value);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FriendlyEnum friendlyValue = FriendlyEnum.A;
            EnemyEnum enemyValue       = EnemyEnum.A;
            // Outputs "True":
            Console.WriteLine(friendlyValue.In(FriendlyEnum.A, FriendlyEnum.C));
            // Outputs "False":
            Console.WriteLine(friendlyValue.In(FriendlyEnum.B, FriendlyEnum.C));
            // All of these will result in compiler errors, 
            // because EnemyEnum is invading some way or another:
            Console.WriteLine(friendlyValue.In(EnemyEnum.A, EnemyEnum.B));
            Console.WriteLine(enemyValue.In(FriendlyEnum.A, FriendlyEnum.B));
            Console.WriteLine(enemyValue.In(EnemyEnum.A, EnemyEnum.B));
        }
    }
