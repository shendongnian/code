        public static string ATexto<T>(this T enumeración) where T : struct, Enum {
            var tipo = enumeración.GetType();
            var textoDirecto = enumeración.ToString();
            string obtenerTexto(string textoDirecto) => tipo.GetMember(textoDirecto)
                .Where(x => x.MemberType == MemberTypes.Field && ((FieldInfo)x).FieldType == tipo)
                .First().GetCustomAttribute<DisplayAttribute>()?.Name ?? textoDirecto;
            
            if (textoDirecto.Contains(", ")) {
                var texto = new StringBuilder();
                foreach (var textoDirectoAux in textoDirecto.Split(", ")) {
                    texto.Append($"{obtenerTexto(textoDirectoAux)}, ");
                }
                return texto.ToString()[0..^2];
            } else {
                return obtenerTexto(textoDirecto);
            }
        } 
