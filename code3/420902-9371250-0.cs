    public class Intermediate : WhateverYourBaseWas {
        public Intermediate(string connectionString, string containerName) : base(connectionString, containerName) {
            this.Connection.StateChange += Connection_StateChange;
        }
    }
