    public class Statutes
    {
        public byte ID { get; set; }
        public string Name { get; set; }
        public Statutes() { }
        public Statutes(byte id, string name)
        {
            ID = id;
            Name = name;
        }
        /// <summary>
        /// Get all the posible statuses of selected <paramref name="type"/>
        /// </summary>
        /// <param name="type">Type of the status</param>
        /// <param name="addDefault">Check if add a default / NULL status</param>
        /// <returns>A list with the statuses</returns>
        public static List<Statutes> SelectAll(Type type, bool addDefault = false)
        {
            var statusesEnum = Enum.GetValues(type);
            List<Statutes> statuses = new List<Statutes>();
            if (addDefault)
                statuses.Add(new Statutes(0, "-"));
            foreach (var statusEnum in statusesEnum)
                statuses.Add(new Statutes((byte)statusEnum, Enum.GetName(type, statusEnum)));
            return statuses;
        }
    }
    public class JSONUtils
    {
        /// <summary>
        /// Get all the posible statuses of selected <paramref name="type"/> in JSON
        /// </summary>
        /// <param name="type">Type of the status</param>
        /// <param name="addDefault">Check if add a default / NULL status</param>
        /// <returns>A string JSON for jQGrid with the statuses</returns>
        public static string GetStatusesJQGrid(Type type, bool addDefault = false)
        {
            var statuses = Statutes.SelectAll(type, addDefault);
            string result = "{value: {";
            foreach (Statutes status in statuses)
                result += String.Format("{0}: '{1}', ", status.ID, status.Name);
            return result.Substring(0, result.Length - 2) + "}}";
        }
    }
