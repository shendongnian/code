    using System;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            static void Main()
            {
                string dateString = "Invalid Date";
                var tryParseDateTask = new Task<TryResult<DateTime>>(() =>
                {
                    DateTime result;
                    if (DateTime.TryParse(dateString, out result))
                        return TryResult<DateTime>.Success(result);
                    else
                        return TryResult<DateTime>.Failure();
                });
                tryParseDateTask.Start();
                if (tryParseDateTask.Result.IsSuccessful)
                    Console.WriteLine(dateString + " was parsed OK.");
                else
                    Console.WriteLine(dateString + " was parsed as " + tryParseDateTask.Result.Value);
            }
        }
        public class TryResult<T>
        {
            public static TryResult<T> Success(T value)
            {
                return new TryResult<T>(value, true);
            }
            public static TryResult<T> Failure()
            {
                return new TryResult<T>(default(T), false);
            }
            TryResult(T value, bool isSuccessful)
            {
                this.value = value;
                this.isSuccessful = isSuccessful;
            }
            public T Value
            {
                get
                {
                    return value;
                }
            }
            public bool IsSuccessful
            {
                get
                {
                    return isSuccessful;
                }
            }
            readonly T value;
            readonly bool isSuccessful;
        }
    }
