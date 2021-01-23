        public Reporter(String inputModel, String outputPdf, Dictionary<String, IParameter> parameters, ResourceManager resman)
        {
            // Assigne parameters to globals
            _sourceFile = inputModel;
            _destinationFile = outputPdf;
            _parameters = parameters;
            _rm = resman;
            Worker();
        }
        private String parseResource(String val)
        {
            MatchCollection _matches = _resourceMatcher.Matches(val);
            foreach (Match _match in _matches)
            {
                String _item = _match.Groups["item"].Value;
                val = val.Replace(_match.Groups[0].Value, String.Format("{0}", _rm.GetObject(_item)));                
            }
            return val;
        }
