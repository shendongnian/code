    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    /// <summary>
    /// Get a random password.
    /// </summary>
    /// <param name="valid">A list of valid password chars.</param>
    /// <param name="length">The length of the password.</returns>
    /// <returns>A random password.</returns>
    public static string GetPassword(IList<char> valid, int length = 13)
    {
        return new string(GetRandomSelection(valid, length).ToArray());
    }
    /// <summary>
    /// Gets a random selection from <paramref name="valid"/>.
    /// </summary>
    /// <typeparam name="T">The item type.</typeparam>
    /// <param name="valid">List of valid possibilities.</param>
    /// <param name="length">The length of the result sequence.</param>
    /// <returns>A random sequence</returns>
    private static IEnumerable<T> GetRandomSelection<T>(
            IList<T> valid,
            int length)
    {
        // The largest multiple of valid.Count less than ulong.MaxValue.
        // This upper limit prevents bias in the results.
        var max = ulong.MaxValue - (ulong.MaxValue % (ulong)valid.Count);
        // A finite sequence of random ulongs.
        var ulongs = RandomUInt64Sequence(max, length).Take(length);
        // A sequence of indecies.
        var indecies = ulongs.Select((u => (int)(u % (ulong)valid.Count)));
        return indecies.Select(i => valid[i]);
    }
    /// <summary>
    /// An infinite sequence of random <see cref="ulong"/>s.
    /// </summary>
    /// <param name="max">
    /// The maximum inclusive <see cref="ulong"/> to return.
    /// </param>
    /// <param name="poolSize">
    /// The size, in <see cref="ulong"/>s, of the pool used to
    /// optimize <see cref="RNGCryptoServiceProvider"/> calls.
    /// </param>
    /// <returns>A random <see cref="ulong"/> sequence.</returns>
    private static IEnumerable<ulong RandomUInt64Sequence(
            ulong max = UInt64.MaxValue,
            int poolSize = 100)
    {
        var rng = new RNGCryptoServiceProvider();
        var pool = new byte[poolSize * sizeof(ulong)];
        while (true)
        {
            rng.GetBytes(pool);
            for (var i = 0; i < poolSize; i++)
            {
                var candidate = BitConvertor.ToUInt64(pool, i * sizeof(ulong));
                if (candidate > max)
                {
                    continue;
                }
                yield return candidate;
            }
        }
    }
