    List<Medication> meds = Medications
        .Where( med =>
            names.Any( name =>
                name.Equals( med.BrandName ) || med.GenericName.Contains( name )
            )
        )
        .ToList();
