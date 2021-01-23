        static bool IsUnparsedEntityReferenceError_BasedOnSerializer(
            XmlSchemaException error)
        {
            if (error == null)
            {
                return false;
            }
            else
            {
                SerializationInfo info = new SerializationInfo(
                    typeof(XmlSchemaException), new FormatterConverter());
                error.GetObjectData(info, default(StreamingContext));
                return "Sch_UnparsedEntityRef" == info.GetString("res");
            }
        }
