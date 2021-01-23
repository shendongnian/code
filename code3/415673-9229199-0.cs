        /// <summary>
        /// Return last check-in History of a file
        /// </summary>
        /// <param name="filename">filename for which history is required</param>
        /// <returns>TFS history command</returns>
        private string GetTfsHistoryCommand(string filename)
        {
            //tfs history command (return only one recent record stopafter:1)
            return string.Format("history /stopafter:1 {0} /noprompt", filename);    // return recent one row
        }
