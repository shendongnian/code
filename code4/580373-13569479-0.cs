    class Cache
    {
        private HubClient _hubClient;
        private IDictionary<string, string> _oldIncidents;
    
        public Cache(HubClient hubClient)
        {
            _hubClient = hubClient;
            _oldIncidents = new Dictionary<string, string>();
        }
    
        public bool IsIncidentAppointmentNew(string currentIncidentAppointment)
        {
            return DoMagicWork(
                incidentKey: "appointment",
                currentIncident = currentIncidentAppointment
            );
        }
        public bool IsIncidentUntreatedNew(string currentIncidentUntreated)
        {
            return DoMagicWork(
                incidentKey: "untreated",
                currentIncident = currentIncidentUntreated
            );
        }
    
        public bool IsIncidentGeneralNew(string currentIncidentGeneral)
        {
            return DoMagicWork(
                incidentKey: "general",
                currentIncident = currentIncidentGeneral
            );
        }
        private bool DoMagicWork(string incidentKey, string currentIncident)
        {
            var oldIncident = _oldIncidents[incidentKey];
            if (XElement.Equals(oldIncident, currentIncident))
            {
                return false;
            }
            
            _oldIncidents[incidentKey] = currentIncident;
            _hubClient.SendToHub();
            return true;
        }
    }
