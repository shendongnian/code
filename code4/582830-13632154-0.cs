    public static IVisit GetVisitInstance(VisitType typeToCreate)
    {
         switch(typeToCreate)
         {
            case VisitType.All:
               return new Visit();
            case VisitType.Inpatient:
                return new InpatientVisit();
            case VisitType.Clinic:
                return new ClinicVisit();
            case VisitType.Emergency:
                return new EmergencyVisit();
            case VisitType.DaySurgery:
                return new DaySurgeryVisit();
            default:
                return null;
         }
    } 
