        public void AgregaPersona(_Persona persona)
        {
               Persona per = new Persona()
                {
                    Nombres = persona.nombres,
                    ApellidoP = persona.apellidoP,
                    ApellidoM = persona.apellidoM,
                    FechaNacimiento = persona.fechaNacimiento,
                    Sexo = persona.sexo.ToString(),
                    EdoCivil = persona.edoCivil,
                    RFC = persona.RFC,
                    CURP = persona.CURP,
                    Domicilio = persona.domicilio,
                    CP = persona.codigoPostal,
                    Telefonos = persona.telefonos,
                    Celular = persona.celular,
                    Email = persona.email,
                    IDDel = persona.idDelegacion,
                    IDEmpresa = persona.idEmpresa
                };
                Referencia newRef = new Referencia
                {
                    Nombre = referenciaNombre;
                    //Fill the rest of the properties except ID (this should be auto)
                }
                per.Referencias.Add(newRef);
                context.personas.AddObject(per);
                context.SaveChanges();
        }
