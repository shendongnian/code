        public static bool Contains<T>(this IList<T> container, T? content)
        {
            if (content.HasValue)
                if (container.Contains(content.Value))
                    return true;
            return false;
        }
